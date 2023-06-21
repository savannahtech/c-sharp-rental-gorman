namespace Data.Interfaces;

public interface IBaseEntity
{
    /// <summary>
    /// Created on
    /// </summary>
    DateTime CreatedOn { get; set; }

    /// <summary>
    /// Updted on
    /// </summary>
    DateTime? UpdatedOn { get; set; }
}