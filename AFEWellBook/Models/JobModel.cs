/*
 * Created by SharpDevelop.
 * User: Glenn
 * Date: 6/12/2016
 * Time: 2:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace AFEWellBook.Models
{
	/// <summary>
	/// This model will contain all info pertaining to specific jobs like status, vendor, due date, etc
	/// </summary>
	public class JobModel
	{
		
		int JobID 			{ set;get; }
 		string JobName 	{ set; get; }
 		DateTime DateDue 	{ set; get; }
 		DateTime DatePosted 	{ set; get; }
 		//can't remember all the columns, but we get the idea			

	}
	
	public class MovieDBContext : DbContext 
	{
		 public DbSet<JobModel> Job { get; set; } 
	}
}
