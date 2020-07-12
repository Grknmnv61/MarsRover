using BusinessLayer.Enums;


namespace BusinessLayer
{
    public interface IRover : ICoordinate
    {
        Plato Plato { get; set; }
        DirectionEnum Direction { get; set; }
        string MovementInformation { get; set; }

        void Move(DirectionEnum direction);
        void TurnLeft90(DirectionEnum direction);
        void TurnRight90(DirectionEnum direction);
        string GetRoverLocationInformation();
    }
}
