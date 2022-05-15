using System.Collections.Generic;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
{
    public class InstructionsController
    {
        private readonly InstructionsService _service;
        public InstructionsController(InstructionsService instructionsService)
        {
            _service = instructionsService;
        }

        public List<Instructions> GetAll()
        {
            return _service.GetAll();
        }

    }
}
