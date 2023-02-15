namespace AssociatedValueEnum
{
    public interface IBarcode {

        public UPC Upc(int numberSystem, int manufacturer, int product, int check)
        {
            return new UPC { NumberSystem = numberSystem, Manufacturer = manufacturer, Product = product, Check = check };
        }

        public QRCode QrCode(string productCode)
        {
            return new QRCode { ProductCode = productCode };
        }

    }

    public struct UPC : IBarcode
    {
        public int NumberSystem { get; set; }
        public int Manufacturer { get; set; }
        public int Product { get; set; }
        public int Check { get; set; }
    }

    public struct QRCode : IBarcode
    {
        public string ProductCode { get; set; }
    }  

}
