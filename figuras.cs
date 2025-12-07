using System;

namespace FigurasGeometricas
{
    // Clase Circulo que encapsula el radio y proporciona métodos para área y perímetro
    public class Circulo
    {
        // Atributo privado que representa el radio del círculo
        private double radio;

        // Constructor que inicializa el radio
        public Circulo(double radio)
        {
            this.radio = radio;
        }

        // Método para calcular el área del círculo
        // Fórmula: π * radio^2
        public double CalcularArea()
        {
            return Math.PI * radio * radio;
        }

        // Método para calcular el perímetro (circunferencia) del círculo
        // Fórmula: 2 * π * radio
        public double CalcularPerimetro()
        {
            return 2 * Math.PI * radio;
        }
    }

    // Clase Rectangulo que encapsula base y altura y proporciona métodos para área y perímetro
    public class Rectangulo
    {
        // Atributos privados base y altura
        private double baseRect;
        private double altura;

        // Constructor que inicializa base y altura
        public Rectangulo(double baseRect, double altura)
        {
            this.baseRect = baseRect;
            this.altura = altura;
        }

        // Método para calcular el área del rectángulo
        // Fórmula: base * altura
        public double CalcularArea()
        {
            return baseRect * altura;
        }

        // Método para calcular el perímetro del rectángulo
        // Fórmula: 2 * (base + altura)
        public double CalcularPerimetro()
        {
            return 2 * (baseRect + altura);
        }
    }