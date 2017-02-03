﻿using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace SmallShopFrame.Models
{
    public partial class Product
    {
        public bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0);  }
        }

        public IEnumerable<RuleViolation> GetRuleViolations()
        {
               if (String.IsNullOrEmpty(Name))
                yield return new RuleViolation("Name is empty", "Name");

            yield break;
        }

        partial void OnValidate(ChangeAction action)
        {
            if (!IsValid)
                throw new ApplicationException("Rule violations prevent saving");
        }
    }

    public class RuleViolation
    {
        public string ErrorMessage { get; private set; }
        public string PropertyName { get; private set; }

        public RuleViolation(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public RuleViolation(string errorMessage, string propertyName)
        {
            ErrorMessage = errorMessage;
            PropertyName = propertyName;
        }

  
    }
}