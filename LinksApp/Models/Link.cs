namespace LinksApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Link
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(1028)]
        public string OriginLink { get; set; }

        [StringLength(128)]
        public string ShortLink { get; set; }

        public int RedirectCount { get; set; }
    }
}
