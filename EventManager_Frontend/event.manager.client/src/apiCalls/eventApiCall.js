import axios from "axios/index";
import moment from 'moment';

export function addEvent(state){
    if( state.startTime==="" || state.startDate==="" || state.endTime===""|| state.endDate===""){
        window.confirm("Należy wypełnić wszystkie pola!");
    }

    let startTmp = (moment(state.startDate).format("YYYY-MM-DD").toString() + "T" + state.startTime);
    let endTmp =  (moment(state.endDate).format("YYYY-MM-DD").toString() + "T" + state.endTime);

    axios.post('/event', {ownerId: 1, name: state.name, participantNumber: state.participantNumber, startDate:startTmp, endDate: endTmp, description: state.description })
        .then(()=>{
            window.confirm('Wydarzenie zostało utworzone poprawnie!');
        })
        .catch((err)=>{
            console.log(err);
        });
}

// export async function getAllEvents() {
//     let res = null;
//     axios.get('/event')
//         .then((response) => {
//             console.log(response);
//             res = response;
//         })
//         .catch(function (error) {
//             console.log("err2");
//             console.log(error);
//             res = null;
//         });
//
//     return res;
// }