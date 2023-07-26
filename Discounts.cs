using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping_Kata
{
    public class Discounts
    {
        public string OfferName { get; set; }
        public int QualifyingItemCount { get; set; }
        public double OfferMultiplier { get; set; }

        public Discounts(string offerName)
        {
            switch (offerName)
            {
                case "buyOneGetOne":
                    this.OfferName = offerName;
                    this.QualifyingItemCount = 2;
                    this.OfferMultiplier = 0.5;
                    break;
                case "buyTwoGet15PercentOff":
                    this.OfferName = offerName;
                    this.QualifyingItemCount = 2;
                    this.OfferMultiplier = 0.15;
                    break;
                case "buyThreeGet20PercentOff":
                    this.OfferName = offerName;
                    this.QualifyingItemCount = 3;
                    this.OfferMultiplier = 0.20;
                    break;
                default:
                    throw new Exception("Offer does not exist");
            }
        }
    }
}