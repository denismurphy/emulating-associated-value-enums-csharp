namespace AssociatedValueEnum.Tests
{
    public class BarcodeTests
    {
        [Fact]
        public void TestUPCBarcode()
        {
            IBarcode barcode = new UPC { NumberSystem = 1, Manufacturer = 2, Product = 3, Check = 4 };
            switch (barcode)
            {
                case UPC upc:
                    Assert.Equal(1, upc.NumberSystem);
                    Assert.Equal(2, upc.Manufacturer);
                    Assert.Equal(3, upc.Product);
                    Assert.Equal(4, upc.Check);
                    break;
                case QRCode qrCode:
                    Assert.True(false, "Unexpected QRCode barcode type");
                    break;
            }
        }

        [Fact]
        public void TestQRCodeBarcode()
        {
            IBarcode barcode = new QRCode { ProductCode = "Hello World" };
            switch (barcode)
            {
                case UPC upc:
                    Assert.True(false, "Unexpected UPC barcode type");
                    break;
                case QRCode qrCode:
                    Assert.Equal("Hello World", qrCode.ProductCode);
                    break;
            }
        }
    }
}