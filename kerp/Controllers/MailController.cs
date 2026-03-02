using kerp.Service.MailService;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;

namespace kerp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController(IMailService mailService) : ControllerBase
    {
        private readonly IMailService _mailService = mailService;


        [HttpPost("send")]
        public async Task<IActionResult> Send([FromBody] SendMailDto dto)
        {
            if (dto.ToEmails == null || dto.ToEmails.Count == 0)
            {
                return BadRequest(new { message = "Ən az 1 alıcı email lazımdır." });
            }

            try
            {
                await _mailService.SendMailAsync(dto);
                return Ok(new { message = "Mail uğurla göndərildi." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
