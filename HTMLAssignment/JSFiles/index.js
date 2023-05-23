const enrollmentForm = document.getElementById("enrollment-form");
const enrollmentRecords = document.getElementById("enrollment-records");
const p=document.getElementById("para");
const td1 = enrollmentRecords;
// Function to display record
const showRecords = (data) =>{
    
    td1.innerHTML +=data;
}

const handleSumbit = (e) => {
    e.preventDefault();

    var formInput = enrollmentForm;
    var name = formInput.name.value.trim();
    var email = formInput.email.value.trim();
    var gender = formInput.gender.value;
    var website = formInput.website.value.trim();
    var imageLink = formInput.imageLink.value.trim();
    var skills = [];
    var validmail = /^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$/;
    var letters = /^[A-Za-z ]+$/;
    if(name=="" || !name.match(letters)){
       alert("Invalid name.Name should only contain letters.");
        return;
    }

   
    if (document.getElementById("java").checked) {
        skills.push("Java")
    }
    if (document.getElementById("html").checked) {
        skills.push("HTML")
    }
    if (document.getElementById("css").checked) {
        skills.push("CSS")
    }
    if(skills.length==0){
        skills.push("No skills");
    }

    if (!email.match(validmail)){
      
        alert("Enter valid email address");
        return;

    }

    const rec = {name, email, gender, website, imageLink, skills}
   
    //Adding new enrollment
    addNewEnrollment(rec);

}

// Adding new enrollment data
const addNewEnrollment = (rec) =>{
    const {name, email, gender, website, imageLink, skills} = rec;
    newData =
        `
        <tr>
          <td>
                <div>
                    <p class="m-0"><b>${name}</b></p>
                    <p class="m-0">${gender}</p>
                    <p class="m-0">${email}</p>
                    <a class="m-0" target="_blank" href=${website}>
                    ${website}   
                    </a>
                   
                    <p>${skills.join(", ")}</p>
                </div>
          </td>
          <td>
                <div class="h-100 w-100">
                    <img
                        src=${imageLink}
                        class="img-fluid w-100 h-100 border rounded"
                        alt="image"
                    />
                </div>
            </td>
        </tr>
    `.trim();

   
    showRecords(newData);
}






















