namespace BomberMan.Client.Data
{
    public abstract class StaticElement : GameElement
    {
        protected StaticElement(string imageName, int mapPositionX, int mapPositionY) : base(imageName, mapPositionX, mapPositionY)
        {
        }
    }
}