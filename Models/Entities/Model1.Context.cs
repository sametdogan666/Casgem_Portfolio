﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Casgem_Portfolio.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CasgemPortfolioEntities1 : DbContext
    {
        public CasgemPortfolioEntities1()
            : base("name=CasgemPortfolioEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TblFeature> TblFeatures { get; set; }
        public virtual DbSet<TblService> TblServices { get; set; }
        public virtual DbSet<TblMessage> TblMessages { get; set; }
        public virtual DbSet<TblReference> TblReferences { get; set; }
        public virtual DbSet<TblProject> TblProjects { get; set; }
        public virtual DbSet<TblSkill> TblSkills { get; set; }
        public virtual DbSet<TblResume> TblResumes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TblDepartment> TblDepartments { get; set; }
        public virtual DbSet<TblEmployee> TblEmployees { get; set; }
    }
}
