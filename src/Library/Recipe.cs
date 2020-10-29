//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Full_GRASP_And_SOLID
{
    public class Recipe
    {
        private IList<Step> steps = new List<Step>();

        public Product FinalProduct { get; set; }

        /*  Creator:
            Nos parecio apropiado aplicar el patron Creator para el metodo AddStep, porque Recipe agrega objetos de Step en si misma y los contiene en la lista de steps,
            por esto mismo lo mas adecuado, en vez de pasarle un step, es crearlo dentro del mismo metodo. Tambien cumple mas condiciones del patron creator como que Recipe
            usa de forma cercana al step, como por ejemplo para los metodos GetTextToPrint() y GetProductionCost(),y ademas tambien guarda instancias del mismo.
        */
        public void AddStep(Product input, double quantity, Equipment equipment, int time)
        {
            Step step = new Step(input,quantity,equipment,time);
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        { 
            this.steps.Remove(step);
        }

        // Agregado por SRP
        public string GetTextToPrint()
        {
            string result = $"Receta de {this.FinalProduct.Description}:\n";
            foreach (Step step in this.steps)
            {
                result = result + step.GetTextToPrint() + "\n";
            }

            // Agregado por Expert
            result = result + $"Costo de producción: {this.GetProductionCost()}";

            return result;
        }

        // Agregado por Expert
        public double GetProductionCost()
        {
            double result = 0;

            foreach (Step step in this.steps)
            {
                result = result + step.GetStepCost();
            }

            return result;
        }
    }
}