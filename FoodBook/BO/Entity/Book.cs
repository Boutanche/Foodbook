﻿using System;
using System.Collections.Generic;

namespace BO.Entity
{
    /// <summary>
    /// Représente un objet livre
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Identifiant unique du livre
        /// </summary>
        public int? Id {get; set;}

        /// <summary>
        /// ISBN unique du livre
        /// </summary>
        public string ISBN {get; set;}

        /// <summary>
        /// Titre du livre
        /// </summary>
        public string Title {get; set; }

        /// <summary>
        /// Résumé du livre
        /// </summary>
        public string Description {get; set;}

        /// <summary>
        /// Default constructor for API serialisation
        /// </summary>
        public Book(){}
      
        /// <summary>
        /// Constructeur utilitaire full properties
        /// </summary>
        /// <param name="bookId">Identifiant of book</param>
        /// <param name="iSBN">IBN of book </param>
        /// <param name="title"> Book title </param>
        /// <param name="description">Summary of book</param>
        public Book(int bookId, string iSBN, string title, string description)
        {
            Id = bookId;
            ISBN = iSBN;
            Title = title;
            Description = description;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Book book &&
                   Id == book.Id &&
                   ISBN == book.ISBN &&
                   Title == book.Title &&
                   Description == book.Description;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hashCode = -919968629;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ISBN);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            return hashCode;
        }
    }
}