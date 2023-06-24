﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AlertSystem.Models
{
    public partial class AlertCheck
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public int AlertAssignId { get; set; }
        public bool AskedQ1 { get; set; }
        public bool AskedQ2 { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public bool RecordStatus { get; set; }

        public virtual AlertAssign AlertAssign { get; set; }
    }
}