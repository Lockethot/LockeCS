namespace Lockethot.Math.Geometry.Grids
{
    public interface IShape
    {
        int Dimension { get; }
        int SideCount { get; }
        bool IsRegular { get; }
    }
}
