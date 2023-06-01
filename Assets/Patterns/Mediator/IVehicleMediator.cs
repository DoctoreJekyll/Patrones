namespace Patterns.Mediator
{
    //Esta interfaz es la que hará de mediator
    public interface IVehicleMediator
    {
        public void BrakeRelease();
        public void BrakeUnrelease();
        public void LeftPressed();
        public void RigthPressed();
        
        //Aqui habria que llamar a los metodos para encender luces y tal pero es solo test no hace falta

    }
}