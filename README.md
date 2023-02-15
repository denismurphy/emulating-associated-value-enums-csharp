
# Emulating Associated Value Enums in C#

This repository provides an example of how to emulate Swift's Associated Value Enums in C#. It demonstrates how to create a C# interface that acts like an enum type, and uses default interface methods to provide struct implementations that store associated values.

## Example from Swift Documentation

Let's take an example from the Swift documentation:

    enum Barcode {
        case upc(Int, Int, Int, Int)
        case qrCode(String)
    }

The `Barcode` enum has two cases, `upc` and `qrCode`. The `upc` case has four associated values of type `Int`, and the `qrCode` case has one associated value of type `String`.

## C# Implementation

The best way to emulate this in C# is to create an interface `IBarcode` that acts like the `Barcode` enum type. Each value of the enum has a default interface method and a struct that stores the associated value.

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

In this example, `UPC` and `QRCode` are two structs that implement the `IBarcode` interface. `UPC` has four properties that correspond to the associated values of the `upc` case in the Swift example, and `QRCode` has one property that corresponds to the associated value of the `qrCode` case.

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

## Using the Emulated Enum in C#

To use the emulated enum in C#, you can create an instance of the `IBarcode` interface with the associated values of the struct. For example, to create a `Barcode.upc` instance with values `8`, `85909`, `51226`, and `3`, you would do the following:

    IBarcode barcode = new UPC { NumberSystem = 8, Manufacturer = 85909, Product = 51226, Check = 3 };

To create a `Barcode.qrCode` instance with value `"ABCDEFGHIJKLMNOP"`, you would do the following:

    IBarcode barcode = new QRCode { ProductCode = "ABCDEFGHIJKLMNOP" }; 

You can use the emulated enum in a switch statement to perform different actions depending on the type of the associated value. For example, to print the associated values of a `Barcode.upc` instance or `Barcode.qrCode` instance, you can use the following code:

    switch (barcode)
    {
        case UPC upc:
            Console.WriteLine($"UPC: {upc.NumberSystem}, {upc.Manufacturer}, {upc.Product}, {upc.Check}.");
            break;
        case QRCode qrCode:
            Console.WriteLine($"QR code: {qrCode.ProductCode}.");
            break;
    } 

## Conclusion

This example demonstrates how to emulate Swift's Associated Value Enums in C# using a combination of interfaces and structs. It provides an elegant solution for working with enums with associated values in C#.
