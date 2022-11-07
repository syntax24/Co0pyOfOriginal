﻿using System.Collections.Generic;
using _0_Framework.Application;

namespace CompanyManagment.App.Contracts.Petition
{
    public interface IPetitionApplication
    {
        OperationResult2 Create(CreatePetition command);
        OperationResult2 Edit(EditPetition command);
        EditPetition GetDetails(long id);
        EditPetition GetDetails(long fileId, int boardTypeId);
        List<EditPetition> Search(PetitionSearchModel searchModel);
    }
}