using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System;

namespace HomeworkPlatform.Models
{
    public class UpViewModels
    {
        [Required]
        [Display(Name = "科目")]
        public string Topic { get; set; }

        [Required]
        [Display(Name = "標題")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "內容敘述")]
        public string Content { get; set; }

       
        [Display(Name = "分數")]
        public int Score { get; set; }
        /*
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // 將使用者輸入的字串轉成 Base64String
            // ※TODOl：到 DB 抓使用者資料
            // 假如抓不到系統使用者資料
            // 為了 Demo 用這種寫法，實際請換成判斷 DB 的資料存不存在
            if (Topic==""||Content==""||Title=="")
            {
                yield return new ValidationResult("除分數之外其他為必填");
            }
        }
        */
    }

    public class UpLoadHomeworkModel
    {
    }
}