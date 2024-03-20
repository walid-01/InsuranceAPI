using InsuranceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceAPI.Database
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //relation Insurance => ServiceOrder.Victim
            modelBuilder.Entity<Insurance>()
                .HasMany(insurance => insurance.ServiceOrdersVictim)
                .WithOne(ServiceOrder => ServiceOrder.VictimInsurance)
                .HasForeignKey(ServiceOrder => ServiceOrder.VictimInsuranceID)
                .IsRequired();

            //relation Insurance => ServiceOrder.AtFault
            modelBuilder.Entity<Insurance>()
                .HasMany(insurance => insurance.ServiceOrdersAtFault)
                .WithOne(ServiceOrder => ServiceOrder.AtFaultInsurance)
                .HasForeignKey(ServiceOrder => ServiceOrder.AtFaultInsuranceID);

            //relation Expert => ServiceOrder.AssociatedExpert
            modelBuilder.Entity<Expert>()
                .HasMany(expert => expert.ServiceOrders)
                .WithOne(ServiceOrder => ServiceOrder.AssociatedExpert)
                .HasForeignKey(ServiceOrder => ServiceOrder.AssociatedExpertID)
                .IsRequired();

            //relation ExpertiseReport => ServiceOrder
            modelBuilder.Entity<ServiceOrder>()
                .HasOne(ServiceOrder => ServiceOrder.ExpertiseReport)
                .WithOne(ExpertiseReport => ExpertiseReport.ServiceOrder)
                .HasForeignKey<ExpertiseReport>(ExpertiseReport => ExpertiseReport.ServiceOrderId);

            //relation ExpertiseReport => DamagedPart 
            modelBuilder.Entity<ExpertiseReport>()
                .HasMany(ExpertiseReport => ExpertiseReport.DamagedParts)
                .WithOne(damagedPart => damagedPart.ExpertiseReport)
                .HasForeignKey(damagedPart => damagedPart.ExpertiseReportID);

        }

        public DbSet<Insurance> Insurance { get; set; }
        public DbSet<Expert> Expert { get; set; }
        public DbSet<ServiceOrder> ServiceOrder { get; set; }
        public DbSet<ExpertiseReport> ExpertiseReport { get; set; }
        public DbSet<DamagedPart> DamagedPart { get; set; }

    }
}