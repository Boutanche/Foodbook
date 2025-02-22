﻿using System;
using System.Collections.Generic;

namespace BO.Entity
{
    /// <summary>
    /// Représente un objet Type Of Dish
    /// </summary>
    public class TypeOfDish
    {
        /// <summary>
        /// Identifiant unique du Type Of Dish
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Label du Type Of Dish
        /// </summary>
        public string Wording { get; set; }
        /// <summary>
        /// Default Constructor for API serialisation
        /// </summary>
        public TypeOfDish() { }
        /// <summary>
        /// Utilitary constructor for properties
        /// </summary>
        /// <param name="id_typeOfDish"></param>
        /// <param name="wording"></param>
        public TypeOfDish(int? id_typeOfDish, string wording)
        {
            Id = id_typeOfDish;
            Wording = wording;
        }
        /// <summary>
        /// Générer automatiquement Equals()
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>TypeOfDish</returns>
        public override bool Equals(object obj)
        {
            return obj is TypeOfDish typeOfDish &&
                   Id == typeOfDish.Id &&
                   Wording == typeOfDish.Wording;
        }
        /// <summary>
        /// Générer automatiquement Get Hash Code
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            int hashCode = -1902563005;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Wording);
            return hashCode;
        }
    }
}
