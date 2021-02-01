using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BooksController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                    select BookId,BookName,AuthorName,ReleaseDate from
                        dbo.Books
                          ";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["BooksAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);

            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Book book)
        {
            try
            {
                string query = @"
                insert into dbo.Books values
                (
                    '" + book.BookName + @"'
                    ,'" + book.AuthorName + @"'
                    ,'" + book.ReleaseDate + @"'
                )
                ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["BooksAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);

                }
                return "Added Successfully!";
            }
            catch (Exception e)
            {

                return "Failed to Add! " + e.Message;
            }
        }

        public string Put(Book book)
        {
            try
            {
                string query = @"
                    update dbo.Books set 
                    BookName='" + book.BookName + @"'
                    ,AuthorName='" + book.AuthorName + @"'
                    ,ReleaseDate='" + book.ReleaseDate + @"'
                    where BookId= " + book.BookId + @"
                ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["BooksAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);

                }
                return "Updated Successfully!";
            }
            catch (Exception e)
            {

                return "Failed to Update! " + e.Message;
            }
        }

        public string Delete(int id)
        {
            try
            {
                string query = @"
                    delete dbo.Books 
                    where BookId= " + id + @"
                ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["BooksAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);

                }
                return "Deleted Successfully!";
            }
            catch (Exception)
            {

                return "Failed to Delete!";
            }
        }
        [Route("api/Books/GetAllBookNames")]
        [HttpGet]
        public HttpResponseMessage GetAllBookNames()
        {

            string query = @"
                    select BookName from dbo.Books";

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["BooksAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);

            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
    }
}
