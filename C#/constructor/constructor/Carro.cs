using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace constructor
{
    class Carro
    {
        string marcas;
        string modelos;
        string placas;
        string cores;
        public Carro(string marca, string modelo, string placa, string cor) 
        {
            marcas = marca;
            modelos = modelo;
            placas = placa;
            cores = cor;
        }
        public string mostrarCarro()
        {
            return $"Marca: {marcas}, Modelo: {modelos}, Placa: {placas} Cor: {cores}";
        }
    }
}
