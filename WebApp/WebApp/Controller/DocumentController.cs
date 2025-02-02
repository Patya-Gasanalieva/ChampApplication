using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq.Expressions;
using WebApp.Entities;
using WebApp.Models;

namespace WebApp.Controller
{
    [Route("api/v1/")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        // запрос для получения списка документов
        [HttpGet("Documents")]
        public async Task<ActionResult<IEnumerable<DocumentModel>>> GetDocument()
        {
            try
            {
                // подключение базы для получения данных 
                using (var db = new DbPersonalManagementContext())
                {
                    // получение данных в виде списка
                    var list = await db.Documents.ToListAsync();
                    return Ok(list.ConvertAll(p => new DocumentModel(p)));
                }
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
          }
          
         
            
        








        // запрос для получения списка комментариев к документу
        [HttpGet("Document/{documentId}/Comments")]
        public async Task<ActionResult<IEnumerable<CommentModel>>> GetComment(int documentId)
        {
            try
            {
               // подключение базы для получения данных 
                using (var db = new DbPersonalManagementContext())
                {
                  
                    var list = await db.Comments.Include(p => p.Author).Include(p => p.Author.Position).Where(p => p.DocumentId == documentId).ToListAsync();
                    if (list.Count == 0)
                    {
                        return StatusCode(404, "Не найдены комментарии для документа");
                    }
                    return Ok(list.ConvertAll(p => new CommentModel(p)));
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
     }







       // запрос для добавления комментария к документу
        [HttpPost("Document/{documentId}/Comment")]
        public async Task<ActionResult> PostComment([FromBody] CommentRequest comment)
        {
            try
            {
              // подключение базы для получения данных
                using (var db = new DbPersonalManagementContext())
                {
                // 
                    var document = db.Documents.Where(p => p.Id == comment.DocumentId).FirstOrDefault();
                    if (document == null)
                    {
                        return BadRequest("Документ не найден");
                    }

                    //Создание нового объекта комментария для добавления в базу
                    var commentAdd = new Comment()
                    {
                        DocumentId = comment.DocumentId,
                        Text = comment.Text,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        AuthorId = comment.AuthorId,
                    };

                  // добавление комментария
                    await db.AddAsync(commentAdd);
                    await db.SaveChangesAsync();
                    return Ok("Комментарий добавлен");
                }
            }
            catch (Exception ex) 
            {
                return StatusCode(400, "Неправильно сформирован запрос {0}" + ex.Message);
            }
        }
    }
    }

