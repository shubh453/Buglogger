using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Buglogger.Domain.Common
{
    public abstract class AuditableEntity : BaseEntity
    {
        public DateTime CreatedOn { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public Guid? ModifiedBy { get; set; }
    }
}
