using System.ComponentModel.DataAnnotations;

namespace BiletBankCaseStudy.Core.Persistence.Repositories;

public class Entity<TId> : IEntityTimestamps
{
    private TId _id;

    [Key]
    public TId Id
    {
        get { return _id; }
        set { _id = value; }
    }
    public byte Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }

    public Entity()
    {
        Id = default;
    }

    public Entity(TId id)
    {
        Id = id;
    }
}
