﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AlertSystem.Models
{
    public partial class AlertStatus
    {
        public AlertStatus()
        {
            Alert = new HashSet<Alert>();
            AlertAssign = new HashSet<AlertAssign>();
        }

        public int Id { get; set; }
        public string StatusName { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? LastUpdateBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public bool RecordStatus { get; set; }

        public virtual ICollection<Alert> Alert { get; set; }
        public virtual ICollection<AlertAssign> AlertAssign { get; set; }
    }
}