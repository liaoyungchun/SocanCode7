var ver = { 2005: '9.00', 2008: '10.00', 2010: '11.00' };

var projGuid = {
    MySqlDAL: '21345BD6-DF92-45E3-88D6-DAA602565135',
    OracleDAL: '46E7B038-1F11-43DF-8E3F-9433A9E73C2B',
    SQLiteDAL: '0DCA1605-1E2C-432A-BA95-7F6E42E0C46A',
    SQLServerDAL: '17691D95-B5E5-421A-A9E1-2658774C6789',
    AseDAL: '259ADA99-E6DE-416E-96DD-441237C75F22',
    DB2DAL: 'F96C7670-20BF-4E19-B7EA-6186F72F9377',
    PostgreSqlDAL: '60F7478C-3A77-49DA-9C7A-1255AE0D804E',
    DAL: 'A1C48560-48CB-456E-868A-465D52702590',
    BLL: '95739FF5-08BA-4639-90AA-DFBCC2E3921F',
    BLS: '1ADC1C06-8428-45C4-95F8-21825B02CDDC'
};
function sln() {
    var NewLine = '\n';
    var temp = 'Microsoft Visual Studio Solution File, Format Version {0}'.format(ver[set.VSVersion]) + NewLine;
    temp += '# Visual Studio ' + set.VSVersion + NewLine;
    temp += 'Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "Model", "Model\\Model.csproj", "{80106719-8219-4348-91FD-493DAA19B5A3}"' + NewLine;
    temp += 'EndProject' + NewLine;
    temp += 'Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "DBUtility", "DBUtility\\DBUtility.csproj", "{BADDC2BE-DD90-49F7-88CD-A21E93663172}"' + NewLine;
    temp += 'EndProject' + NewLine;
    temp += 'Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "{0}", "{0}\\{0}.csproj", "{{1}}"'.format(set.DALFrame, projGuid[set.DALFrame]) + NewLine;
    temp += 'EndProject' + NewLine;
    temp += 'Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "BLL", "{0}\\{0}.csproj", "{{1}}"'.format(set.BLFrame, projGuid[set.BLFrame]) + NewLine;
    temp += 'EndProject' + NewLine;
    if (set.SlnFrame == 'Factory') {
        temp += 'Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "IDAL", "IDAL\\IDAL.csproj", "{39D002DA-E074-4237-9069-87B47297C02D}"' + NewLine;
        temp += 'EndProject' + NewLine;
        temp += 'Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "DALFactory", "DALFactory\\DALFactory.csproj", "{4EAABE68-E8A3-4D35-9743-09468EB44C29}"' + NewLine;
        temp += 'EndProject' + NewLine;
    }
    temp += 'Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "Web", "Web\\Web.csproj", "{461FAB5B-051A-40E0-B6AB-6D31D19553ED}"' + NewLine;
    temp += 'EndProject' + NewLine;

    return {
        title: 'Solution',
        path: 'socansoft.sln',
        code: temp
    };
}