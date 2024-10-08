﻿using System;
using System.Collections.Generic;

namespace Demo.Models;

public partial class Activity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
