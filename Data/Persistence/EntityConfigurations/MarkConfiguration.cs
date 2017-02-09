using AthleticMarks.Data.Entities.Domain;
using System.Data.Entity.ModelConfiguration;

namespace AthleticMarks.Data.Persistence.EntityConfigurations
{
    public class MarkConfiguration : EntityTypeConfiguration<Mark>
    {
        public MarkConfiguration()
        {
            HasMany(m => m.Athletes)
                .WithMany(a => a.Marks)
                .Map(x =>
                {
                    x.MapLeftKey("MarkId");
                    x.MapRightKey("AthleteId");
                    x.ToTable("MarkAthlete");
                });
        }
    }
}