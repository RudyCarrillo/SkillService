using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using Neo4jClient;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for SkillsService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SkillsService : System.Web.Services.WebService
    {

        GraphClient graphClient;
        public SkillsService()
        {
            graphClient = new GraphClient(new Uri("http://localhost:7474/db/data"), "", "");
            graphClient.Connect();
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string createProject(string projectName)
        {
            string result = "";

            if (projectName != "")
            {
                Project newProject = new Project(projectName);
                graphClient.Cypher
                    .Merge("(proj:Project {name: {name}})")
                    .OnCreate()
                    .Set("proj = {newProject}")
                    .WithParams(new
                    {
                        name = newProject.getName(),
                        newProject
                    })
                    .ExecuteWithoutResults();
                result = "The project has been created.";
                return result;
            }
            else
            {
                result = "The project need a name.";
                return result;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string createEmployee(string employeeName)
        {
            string result = "";

            if (employeeName != "")
            {
                EMP newEmployee = new EMP(employeeName);
                graphClient.Cypher
                    .Merge("(emp:EMP {name: {name}})")
                    .OnCreate()
                    .Set("emp = {newEmployee}")
                    .WithParams(new
                    {
                        name = newEmployee.getName(),
                        newEmployee
                    })
                    .ExecuteWithoutResults();
                result = "The employee has been created.";
                return result;
            }
            else
            {
                result = "The employee need a name.";
                return result;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string createSkill(string skillName)
        {
            string result = "";

            if (skillName != "")
            {
                Skill newSkill = new Skill(skillName);
                graphClient.Cypher
                    .Merge("(skill:Skill {name: {name}})")
                    .OnCreate()
                    .Set("skill = {newSkill}")
                    .WithParams(new
                    {
                        name = newSkill.getName(),
                        newSkill
                    })
                    .ExecuteWithoutResults();
                result = "The skill has been created.";
                return result;
            }
            else
            {
                result = "The skill need a name.";
                return result;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string read(string name)
        {
            string ret = "";

            var result = graphClient.Cypher
                    .Match("(EMP)-[:knows]->(Skill)")
                    .Where("EMP.name = {name}")
                    .WithParam("name", name)
                    .Return((EMP, Skill) => new
                    {
                        Employee = EMP.As<EMP>(),
                        Skills = Skill.CollectAs<Skill>()
                     })
                     .Results.Single();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            ret = jss.Serialize(result);
            
            return ret;
            //return new JavaScriptSerializer().Serialize(parentsList);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string readSkillsJr(string name)
        {
            string ret = "";
            

            var result = graphClient.Cypher
                    .Match("(EMP)-[sk1:knows]->(Skill)")
                    .Where("EMP.name = {name} and sk1.value = {val}")
                    .WithParam("name", name)
                    .WithParam("val", "1")
                    .Return((EMP, Skill) => new
                    {
                        Employee = EMP.As<EMP>(),
                        Skills = Skill.CollectAs<Skill>()
                    })
                     .Results.Single();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            ret = jss.Serialize(result);

            return ret;
            //return new JavaScriptSerializer().Serialize(parentsList);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string readSkillsInterm(string name)
        {
            string ret = "";


            var result = graphClient.Cypher
                    .Match("(EMP)-[sk1:knows]->(Skill)")
                    .Where("EMP.name = {name} and sk1.value = {val}")
                    .WithParam("name", name)
                    .WithParam("val", "2")
                    .Return((EMP, Skill) => new
                    {
                        Employee = EMP.As<EMP>(),
                        Skills = Skill.CollectAs<Skill>()
                    })
                     .Results.Single();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            ret = jss.Serialize(result);

            return ret;
            //return new JavaScriptSerializer().Serialize(parentsList);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string readSkillsSr(string name)
        {
            string ret = "";


            var result = graphClient.Cypher
                    .Match("(EMP)-[sk1:knows]->(Skill)")
                    .Where("EMP.name = {name} and sk1.value = {val}")
                    .WithParam("name", name)
                    .WithParam("val", "3")
                    .Return((EMP, Skill) => new
                    {
                        Employee = EMP.As<EMP>(),
                        Skills = Skill.CollectAs<Skill>()
                    })
                     .Results.Single();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            ret = jss.Serialize(result);

            return ret;
            //return new JavaScriptSerializer().Serialize(parentsList);
        }


        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] readEmp(string name)

        {
            string[] parentsList = graphClient.Cypher
                     .Match("(child:EMP)")
                     .Where("child.name = {name}")
                     .WithParam("name", name)
                     .Return(child => child.As<EMP>().name)
                     .Results.ToArray();

            return parentsList;
            //return new JavaScriptSerializer().Serialize(parentsList);
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] readEmps()

        {
            string[] parentsList = graphClient.Cypher
                     .Match("(emp:Emp)")
                     .Return(emp => emp.As<EMP>().name)
                     .Results.ToArray();

            return parentsList;
            //return new JavaScriptSerializer().Serialize(parentsList);
        }


        [WebMethod]
        public string update(string name, string parent)
        {
            string result = "";
            if (name != "" && parent != "")
            {
                graphClient.Cypher
                 .Match("(elemA), (elemB)")
                 .Where("elemA.name = {nameA}")
                 .WithParam("nameA", name)
                 .AndWhere("elemB.name = {nameB}")
                 .WithParam("nameB", parent)
                 .Create("(elemA)-[:DERIVED_FROM]->(elemB)")
                 .ExecuteWithoutResults();
            }
            return result;
        }

        [WebMethod]
        public string delete(string name)
        {
            string result = "";
            //string min = "";
            //string label = "";

            //if(element == "project")
            //{

            //    min = "proj";
            //    label = "Project";

            //} else if(element == "employee")
            //{

            //    min = "emp";
            //    label = "Employee";

            //}
            //else if(element == "skill")
            //{

            //    min = "skill";
            //    label = "Skill";

            //}

            if (name != "")
            {
                graphClient.Cypher
                    .OptionalMatch("(n)")
                    .Where("n.name = {name}")
                    .WithParam("name", name)
                    .DetachDelete("n")
                    .ExecuteWithoutResults();
            }

            return result;
        }

        public class Project
        {
           

            public Project()
            {

            }

            public string name
            {
                get;set;
            }

            public Project(string name)
            {
                this.name = name;
            }

            public string getName()
            {
                return name;
            }

            public void setName(string name)
            {
                this.name = name;
            }
        }

        public class EMP
        {
            public string name
            {
                get;set;
            }

            public EMP() { }

            public EMP(string name)
            {
                this.name = name;
            }

            public string getName()
            {
                return name;
            }

            public void setName(string name)
            {
                this.name = name;
            }


        }

        public class Skill
        {
            public Skill()
            {

            }
            public string name
            {
                get;set;
            }

            public Skill(string name)
            {
                this.name = name;
            }

            public string getName()
            {
                return name;
            }

            public void setName(string name)
            {
                this.name = name;
            }
        }
    }
}
