﻿using KutuphaneApp.Business.Abstract;
using KutuphaneApp.Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneApp.Business.Concrate
{
	public class BookService : EfRepositoryBase<Book, KutuphaneAppContext>, IBookService
	{
	}
}
