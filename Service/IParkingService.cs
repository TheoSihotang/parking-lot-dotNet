public interface IParkingService{
    void SetSlot(int slot);
    void Park(ParkingLot parkingLot);
    void Leave (int number);
    void Status();
    void TypeOf(string type);
    void OddPlate();
    void EvenPlate();
    void Color(string color);
    void SlotWithColor(string color);
    void SlotPlate(string plate);
}