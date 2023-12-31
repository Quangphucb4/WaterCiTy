﻿using System.ComponentModel.DataAnnotations.Schema;

namespace WaterCity.Contract.Repository.Models
{
    [Table("NhatKyDuLieu")]
    public class NhatKyDuLieuEntity : Entity
    {
        public string NhanVienId { get; set; }


        public DateTimeOffset ThoiGian { get; set; }

        public string MoTa { get; set; }

        public string Ip { get; set; }

        public string SuKien { get; set; }

        public string DuLieuTruoc { get; set; }

        public string DuLieuSau { get; set; }


        public string NhaMayId { get; set; }


        public string ThuocBang { get; set; }

    }
}
