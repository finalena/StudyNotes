using Ex_11_035_20.FileValidatons;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_11_035_20
{
    class Program
    {
		/* 低耦合力的好處-可擴展性
         * - 針對網頁上傳檔案，開發一個驗證輔助類別
         * - 它在不同專案/網頁裡會有不同驗證規則，所以可以事先宣告一個介面，日後隨時增減驗證規則
         * - 目前已實作的規則有兩個 ： 必填，檔案不能過大
		 * - 新增驗證規則:檔案副檔名必需為 .jpg, .png, 或者.jpeg (C# 11_035_25)
         */
		static void Main(string[] args)
        {
			//照片驗證規則
            var displayName = "照片";
            var requiredRule = new Required(displayName);
            var maxLengthRule = new MaxLength(displayName, 2);
			var fileExtension = new FileExtension(displayName, "*.jpg;*.png;*.jpeg");

			//要驗證的檔案
            //var file = new FileImp1("123.jpg", 1);
			var file = new FileImp1(null, 8000);

			//對檔案新增驗證規則
            var validator = new FileValidator(displayName, file);
			validator.ValidationRules = new List<IFileValidationRule>
			{
				requiredRule,
				maxLengthRule,
				fileExtension
			};

			//開始驗證
            var result = validator.Vaild();
            DisplayResult(result);
            Console.WriteLine("=============");

            Console.ReadLine();          
        }

        private static void DisplayResult(ValidationResult result)
        {
            if (result.Success)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
            
        }
    }

    public interface IFile
    {
        int ContentLength { get; }
        string FileName { get; }
		string FileExtension { get; set; }
    }

    public class FileImp1 : IFile
	{
		private string _fileExtension;

		public int ContentLength { get; }
        public string FileName { get; }
		public string FileExtension
		{
			get { return _fileExtension; }
			set
			{
				if (!string.IsNullOrWhiteSpace(value) && value.Contains('.'))
				{
					string sFileExtension = value.Substring(value.LastIndexOf('.'));
					_fileExtension = sFileExtension;
				}
				else
				{
					_fileExtension = string.Empty;
				}
			}
		}

		public FileImp1(string fileName, int ContentLength)
        {
            this.FileName = fileName;
            this.ContentLength = ContentLength;
			this.FileExtension = fileName;
        }
    }

    public class FileValidator
    {
        private readonly string _displayName;
        private readonly IFile _file;
        public List<IFileValidationRule> ValidationRules { get; set; }
        public FileValidator(string displayName, IFile file)
        {
            _displayName = displayName;
            _file = file;
            ValidationRules = new List<IFileValidationRule>();
        }

        public ValidationResult Vaild()
        {
            if (ValidationRules == null || ValidationRules.Count == 0) return ValidationResult.GetSuccess();
            List<string> errorMessages = new List<string>();
            foreach (var validationRule in ValidationRules)
            {
                var result = validationRule.Valid(this._file);
                if (!result.Success) errorMessages.Add(result.ErrorMessage);
            }

            return errorMessages.Count == 0
                ? ValidationResult.GetSuccess()
                : ValidationResult.GetError(errorMessages);
        }
    }

    public interface IFileValidationRule
    {
        ValidationResult Valid(IFile file);
    }

    namespace FileValidatons
    {
        public abstract class BaseValidationRule : IFileValidationRule
        {
            protected readonly string _displayName;

            public BaseValidationRule(string displayName)
            {
                _displayName = displayName;
            }

            public abstract ValidationResult Valid(IFile file);
        }

        public class Required: BaseValidationRule
        {
			//父類別沒有空建構式，子類別必需明確指定使用哪一個父類別的建構式
			public Required(string displayName) : base(displayName) 
            { }

            public override ValidationResult Valid(IFile file)
            {
                return (file == null || file.ContentLength == 0)
                    ? ValidationResult.GetError($"{_displayName}必填")
                    : ValidationResult.GetSuccess();
            }
        }

        public class MaxLength : BaseValidationRule
        {
            private readonly int _maxKBs;
            public MaxLength(string displayName, int maxKBs) : base(displayName)
            {
                _maxKBs = maxKBs;
            }

            public override ValidationResult Valid(IFile file)
            {
                if (file == null || file.ContentLength == 0) return ValidationResult.GetSuccess();

                return (file.ContentLength / 1024 > _maxKBs)
                    ? ValidationResult.GetError($"{_displayName} 超過限制 {_maxKBs} KB(s)")
                    : ValidationResult.GetSuccess();
            }
        }

		public class FileExtension : BaseValidationRule
		{
			private readonly string _FileExtensions;
			public FileExtension(string displayName, string fileExtensions) : base(displayName)
			{
				_FileExtensions = fileExtensions;
			}

			public override ValidationResult Valid(IFile file)
			{
				string[] arrFileExtension = _FileExtensions.Split(';');
				string[] conform = arrFileExtension
					.Where(x => !string.IsNullOrEmpty(file.FileExtension) && x.Contains(file.FileExtension))
					.ToArray();

				return (file == null || conform.Length == 0)
				   ? ValidationResult.GetError($"檔案副檔名必需為 {_FileExtensions.Replace(";","、")}")
				   : ValidationResult.GetSuccess();
			}
		}

	}

    public class ValidationResult
    {
        public bool Success { get; private set; }
        public string ErrorMessage { get; private set; }

        private ValidationResult() { }

        public static ValidationResult GetSuccess()
            => new ValidationResult {Success = true, ErrorMessage = string.Empty };

        public static ValidationResult GetError(string errorMessage)
            => new ValidationResult { Success = false, ErrorMessage = errorMessage };

        public static ValidationResult GetError(IEnumerable<string> errorMessages)
        {
            string errorMessage = errorMessages.Aggregate((acc, next) => acc += ", " + next);
            return ValidationResult.GetError(errorMessage);
        }
    } 
}
