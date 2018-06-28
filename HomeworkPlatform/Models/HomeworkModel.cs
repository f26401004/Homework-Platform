using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeworkPlatform.Models
{
    public class HomeworkModel
    {
        public HomeworkModel()
        {

        }
        public HomeworkModel(int id)
        {
            TopicId = id.ToString();
        }
        [BsonId]
        public ObjectId HomeworkId { get; set; }

        [DefaultValue(true)]
        [ScaffoldColumn(false)]
        public string TopicId { get; set; }

        [Required]
        [Display(Name = "標題 Title")]
        [StringLength(60)]
        public string Title { get; set; }


        [DefaultValue(true)]
        [Display(Name = "作者 Author")]
        public string Author { get; set; }

        [Required]
        [Display(Name = "內容 Content")]
        [AllowHtml]
        public string Content { get; set; }

        [Required]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.doc|.docx|.pdf|)$", ErrorMessage = "不允許除了 .doc/.docx/.pdf/.txt/.rar/.zip 外的檔案上傳")]
        [Display(Name = "上傳 Upload")]
        public HttpPostedFileBase UploadFile { get; set; }

        [ScaffoldColumn(true)]
        public string ServerFilePath { get; set; }

        [Display(Name = "分數 Score")]
        public string Score { get; set; }

        [Display(Name = "發布時間 Time")]
        public string Time { get; set; }

        [Display(Name = "瀏覽人數 visits")]
        public int Visits { get; set; }
        [Display(Name = "喜歡 like")]
        public int Like { get; set; }
    }
}