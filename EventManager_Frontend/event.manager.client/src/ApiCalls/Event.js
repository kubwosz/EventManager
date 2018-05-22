import axios from "axios/index";
import ShowEvents from "../components/NewEvent";

export function addEvent(state){
    axios.post('/event', {ownerId: 1, name: state.name, participantNumber: state.participantNumber, startDate: state.startDate, endDate: state.endDate, description: state.description })
        .then(()=>{
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