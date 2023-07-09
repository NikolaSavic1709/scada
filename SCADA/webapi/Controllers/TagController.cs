﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.DTO;
using webapi.model;
using webapi.Model;
using webapi.Repositories;
using webapi.Services;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly IDigitalInputService _digitalInputService;
        private readonly IDigitalOutputService _digitalOutputService;
        private readonly IAnalogInputService _analogInputService;
        private readonly IAnalogOutputService _analogOutputService;
        private readonly IIOAddressRepository _ioAddressRepository;

        public TagController(
            IDigitalInputService digitalInputService,
            IDigitalOutputService digitalOutputService,
            IAnalogInputService analogInputService,
            IAnalogOutputService analogOutputService,
            IIOAddressRepository ioAddressRepository)
        {
            _digitalInputService = digitalInputService;
            _digitalOutputService = digitalOutputService;
            _analogInputService = analogInputService;
            _analogOutputService = analogOutputService;
            _ioAddressRepository = ioAddressRepository;
        }

        // DigitalInput
        [HttpGet("DigitalInputs")]
        public ActionResult<IEnumerable<DigitalInput>> GetDigitalInputs()
        {
            var digitalInputs = _digitalInputService.GetAllDigitalInputs();
            return Ok(digitalInputs);
        }

        [HttpGet("DigitalInputs/{id}")]
        public ActionResult<DigitalInput> GetDigitalInput(int id)
        {
            var digitalInput = _digitalInputService.GetDigitalInputById(id);
            if (digitalInput == null)
            {
                return NotFound();
            }
            return digitalInput;
        }

        [HttpPost("DigitalInputs")]
        public ActionResult<DigitalInput> CreateDigitalInput(DigitalInputCreateDTO digitalInputDTO)
        {
            var ioAddress = new IOAddress
            {
                Type = "bool"
            };

            _ioAddressRepository.Add(ioAddress);

            var digitalInput = new DigitalInput
            {
                Description = digitalInputDTO.Description,
                ScanTime = digitalInputDTO.ScanTime,
                Address = ioAddress,
                IsScanning = true,
                Values = new List<TagValue>()
            };

            _digitalInputService.CreateDigitalInput(digitalInput);

            return Ok(digitalInput);
        }

        [HttpDelete("DigitalInputs/{id}")]
        public IActionResult DeleteDigitalInput(int id)
        {
            _digitalInputService.DeleteDigitalInput(id);
            return NoContent();
        }

        [HttpPut("DigitalInputs/{id}/IsScanning")]
        public IActionResult UpdateDigitalInputScanning(int id, bool isScanning)
        {
            var digitalInput = _digitalInputService.GetDigitalInputById(id);
            if (digitalInput == null)
            {
                return NotFound();
            }

            digitalInput.IsScanning = isScanning;
            _digitalInputService.UpdateDigitalInput(digitalInput);

            return NoContent();
        }

        // DigitalOutput
        [HttpGet("DigitalOutputs")]
        public ActionResult<IEnumerable<DigitalOutput>> GetDigitalOutputs()
        {
            var digitalOutputs = _digitalOutputService.GetAllDigitalOutputs();
            return Ok(digitalOutputs);
        }

        [HttpGet("DigitalOutputs/{id}")]
        public ActionResult<DigitalOutput> GetDigitalOutput(int id)
        {
            var digitalOutput = _digitalOutputService.GetDigitalOutputById(id);
            if (digitalOutput == null)
            {
                return NotFound();
            }
            return digitalOutput;
        }

        [HttpPost("DigitalOutputs")]
        public ActionResult<DigitalOutput> CreateDigitalOutput(DigitalOutputCreateDTO digitalOutputDTO)
        {
            var ioAddress = new IOAddress
            {
                Type = "bool"
            };

            _ioAddressRepository.Add(ioAddress);

            var digitalOutput = new DigitalOutput
            {
                Description = digitalOutputDTO.Description,
                InitialValue = digitalOutputDTO.InitialValue,
                Address = ioAddress,
                Values = new List<TagValue>()
            };

            _digitalOutputService.CreateDigitalOutput(digitalOutput);

            return Ok(digitalOutput);
        }

        [HttpDelete("DigitalOutputs/{id}")]
        public IActionResult DeleteDigitalOutput(int id)
        {
            _digitalOutputService.DeleteDigitalOutput(id);
            return NoContent();
        }

        // AnalogInput
        [HttpGet("AnalogInputs")]
        public ActionResult<IEnumerable<AnalogInput>> GetAnalogInputs()
        {
            var analogInputs = _analogInputService.GetAllAnalogInputs();
            return Ok(analogInputs);
        }

        [HttpGet("AnalogInputs/{id}")]
        public ActionResult<AnalogInput> GetAnalogInput(int id)
        {
            var analogInput = _analogInputService.GetAnalogInputById(id);
            if (analogInput == null)
            {
                return NotFound();
            }
            return analogInput;
        }

        [HttpPost("AnalogInputs")]
        public ActionResult<AnalogInput> CreateAnalogInput(AnalogInputCreateDTO analogInputDTO)
        {
            var ioAddress = new IOAddress
            {
                Type = "double"
            };

            _ioAddressRepository.Add(ioAddress);

            var analogInput = new AnalogInput
            {
                Description = analogInputDTO.Description,
                ScanTime = analogInputDTO.ScanTime,
                LowLimit = analogInputDTO.LowLimit,
                HighLimit = analogInputDTO.HighLimit,
                Unit = analogInputDTO.Unit,
                Address = ioAddress,
                IsScanning = true,
                Values = new List<TagValue>()
            };

            _analogInputService.CreateAnalogInput(analogInput);

            return Ok(analogInput);
        }

        [HttpDelete("AnalogInputs/{id}")]
        public IActionResult DeleteAnalogInput(int id)
        {
            _analogInputService.DeleteAnalogInput(id);
            return NoContent();
        }

        [HttpPut("AnalogInputs/{id}/IsScanning")]
        public IActionResult UpdateAnalogInputScanning(int id, bool isScanning)
        {
            var analogInput = _analogInputService.GetAnalogInputById(id);
            if (analogInput == null)
            {
                return NotFound();
            }

            analogInput.IsScanning = isScanning;
            _analogInputService.UpdateAnalogInput(analogInput);

            return NoContent();
        }


        // AnalogOutput
        [HttpGet("AnalogOutputs")]
        public ActionResult<IEnumerable<AnalogOutput>> GetAnalogOutputs()
        {
            var analogOutputs = _analogOutputService.GetAllAnalogOutputs();
            return Ok(analogOutputs);
        }

        [HttpGet("AnalogOutputs/{id}")]
        public ActionResult<AnalogOutput> GetAnalogOutput(int id)
        {
            var analogOutput = _analogOutputService.GetAnalogOutputById(id);
            if (analogOutput == null)
            {
                return NotFound();
            }
            return analogOutput;
        }

        [HttpPost("AnalogOutputs")]
        public ActionResult<AnalogOutput> CreateAnalogOutput(AnalogOutputCreateDTO analogOutputDTO)
        {
            var ioAddress = new IOAddress
            {
                Type = "double"
            };

            _ioAddressRepository.Add(ioAddress);

            var analogOutput = new AnalogOutput
            {
                Description = analogOutputDTO.Description,
                InitialValue = analogOutputDTO.InitialValue,
                LowLimit = analogOutputDTO.LowLimit,
                HighLimit = analogOutputDTO.HighLimit,
                Unit = analogOutputDTO.Unit,
                Address = ioAddress,
                Values = new List<TagValue>()
            };

            _analogOutputService.CreateAnalogOutput(analogOutput);

            return Ok(analogOutput);

        }

        [HttpDelete("AnalogOutputs/{id}")]
        public IActionResult DeleteAnalogOutput(int id)
        {
            _analogOutputService.DeleteAnalogOutput(id);
            return NoContent();
        }
    }
}
