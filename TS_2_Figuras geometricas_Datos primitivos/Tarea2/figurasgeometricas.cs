using System;

namespace FigurasGeometricas
{
    // Clase Circulo que encapsula el tipo de dato primitivo 'double' para el radio
    // Proporciona métodos públicos para calcular área y perímetro manteniendo el radio privado
    public class Circulo
    {
        // Atributo privado de tipo primitivo double que representa el radio del círculo
        // La encapsulación asegura que solo se acceda a través de métodos públicos
        private double radio;

        // Constructor público que recibe el radio como parámetro de tipo primitivo double
        // Inicializa el atributo privado radio con el valor recibido
        public Circulo(double radio)
        {
            this.radio = radio;
        }

        // CalcularArea es un método público que devuelve un valor double
        // Se utiliza para calcular el área de un círculo usando la fórmula π * radio²
        // No requiere parámetros ya que accede al atributo privado radio
        public double CalcularArea()
        {
            return Math.PI * radio * radio;
        }

        // CalcularPerimetro es un método público que devuelve un valor double
        // Se utiliza para calcular el perímetro (circunferencia) de un círculo usando 2 * π * radio
        // No requiere parámetros ya que accede al atributo privado radio
        public double CalcularPerimetro()
        {
            return 2 * Math.PI * radio;
        }
    }

    // Clase Rectangulo que encapsula los tipos de dato primitivo 'double' para base y altura
    // Proporciona métodos públicos para calcular área y perímetro manteniendo los atributos privados
    public class Rectangulo
    {
        // Atributos privados de tipo primitivo double que representan base y altura del rectángulo
        // La encapsulación protege estos datos de acceso directo desde fuera de la clase
        private double baseRect;
        private double altura;

        // Constructor público que recibe base y altura como parámetros de tipo primitivo double
        // Inicializa los atributos privados con los valores recibidos
        public Rectangulo(double baseRect, double altura)
        {
            this.baseRect = baseRect;
            this.altura = altura;
        }

        // CalcularArea es un método público que devuelve un valor double
        // Se utiliza para calcular el área del rectángulo usando la fórmula base * altura
        // No requiere parámetros ya que accede a los atributos privados
        public double CalcularArea()
        {
            return baseRect * altura;
        }

        // CalcularPerimetro es un método público que devuelve un valor double
        // Se utiliza para calcular el perímetro del rectángulo usando la fórmula 2 * (base + altura)
        // No requiere parámetros ya que accede a los atributos privados
        public double CalcularPerimetro()
        {
            return 2 * (baseRect + altura);
        }
    }
}
