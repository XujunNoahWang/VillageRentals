namespace VillageRentals.CSFiles;

public class OrderUI
{
    public int OrderID { get; set; }
    public int CustomerID { get; set; }
    public int EquipmentID { get; set; }
    public DateTime OrderPlaceDate { get; set; }
    public DateTime OrderRentalDate { get; set; } = DateTime.Today;
    public DateTime OrderReturnDate { get; set; } = DateTime.Today.AddDays(1);
    public DateTime? OrderReturnDateFinal { get; set; }
    public double TotalFee { get; set; }
    public bool OrderIsClosed { get; set; } 

    public OrderUI() { }

    public OrderUI(int orderID, int customerID, int equipmentID, DateTime placeDate, DateTime rentalDate, DateTime returnDate, DateTime? returnDateFinal, double totalFee, bool orderIsClosed = false)
    {
        OrderID = orderID;
        CustomerID = customerID;
        EquipmentID = equipmentID;
        OrderPlaceDate = placeDate;
        OrderRentalDate = rentalDate;
        OrderReturnDate = returnDate;
        OrderReturnDateFinal = returnDateFinal;
        TotalFee = totalFee;
        OrderIsClosed = orderIsClosed;
    }
}