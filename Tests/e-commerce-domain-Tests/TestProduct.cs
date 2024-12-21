﻿using e_commerce_domain.DTO;
using e_commerce_domain.entities.Product;
using System.Text;

namespace e_commerce_domain_Tests.entities.Product
{

    public class TestProduct : ProductBase
    {
        public TestProduct(GenericProductDTO productDTO)
            : base(productDTO)
        {
        }

        public override decimal CalculateTotalValue()
        {
            return GetGrossValue() + (GetGrossValue() * GetTaxPercentaje() / 100) - (GetGrossValue() * GetDisccounPercentaje() / 100);
        }


        public override string GetName()
        {
            return name;
        }

        public override void SetName(string name)
        {
            if (name.Trim().Length <= 5 || name.Length > 20)
            {
                throw new ArgumentOutOfRangeException($"El nombre del producto {name} no puede ser menor a 5 caracteres ni mayor a 20 caracteres");
            }

            this.name = name;
        }

        public override string GetDescription()
        {
            return description;
        }

        public override void SetDescription(string description)
        {
            this.description = description;
        }

        public override decimal GetGrossValue()
        {
            return grossValue;
        }

        public override void SetGrossValue(decimal grossvalue)
        {
            if (grossvalue <= 0)
            {
                throw new ArgumentOutOfRangeException($"El valor base del producto no puede ser menor o igual a 0");
            }
            grossValue = grossvalue;
        }

        public override decimal GetTaxPercentaje()
        {
            return taxPercentaje;
        }

        public override void SetTaxPercentaje(decimal taxpercentaje)
        {
            if (taxpercentaje < 0 || taxpercentaje > 100)
            {
                throw new ArgumentOutOfRangeException($"El porcentaje del impuesto no puede ser menor a 0 ni mayor a 100");
            }

            taxPercentaje = taxpercentaje;
        }

        public override decimal GetDisccounPercentaje()
        {
            return discPercentaje;
        }

        public override void SetDisccountPercentaje(decimal disccountPercentaje)
        {
            if (disccountPercentaje < 0 || disccountPercentaje > 100)
            {
                throw new ArgumentOutOfRangeException($"El porcentaje del descuento no puede ser menor a 0 ni mayor a 100");
            }

            discPercentaje = disccountPercentaje;
        }

        public override int GetStock()
        {
            return stock;
        }

        public override void SetStock(int stock)
        {
            if (stock < 0)
            {
                throw new ArgumentOutOfRangeException($"El stock del producto no puede ser menor a 0");
            }
            this.stock = stock;
        }

        public override string ShowInfo()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine($"El producto {name} de tipo {nameof(TestProduct)} ");
            stringBuilder.AppendLine($"Su costo total es de {CalculateTotalValue()}");
            stringBuilder.AppendLine($"Teniendo en cuenta su volumen y costos de envio");

            return stringBuilder.ToString();
        }
    }

}