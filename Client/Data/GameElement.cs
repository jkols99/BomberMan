namespace BomberMan.Client.Data
{
    public abstract class GameElement
    {
        public const int TileWidth = 50;
        private readonly string _imageName;
        protected int TopPosition { get; set; }
        
        protected int LeftPosition { get; set; }

        protected GameElement(string imageName, int mapPositionX, int mapPositionY)
        {
            this._imageName = imageName;
            TopPosition = mapPositionX * TileWidth;
            LeftPosition = mapPositionY * TileWidth;
        }

        public string CssClass => $"{_imageName} element unselectable";
        
        public string CssStyle => $"top: {TopPosition}px; left: {LeftPosition}px;";
    }
}