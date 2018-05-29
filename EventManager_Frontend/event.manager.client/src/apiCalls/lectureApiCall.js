import axios from "axios/index";

export default function addLecture(state){
    console.log(state);
    axios.post('/lecture', {ownerId: 1, eventId: state.eventId, name: state.name, participantNumber: state.participantNumber, startDate: state.startdate, endDate: state.endDate, description: state.description})
        .then(()=>{
        })
        .catch((err)=>{
            console.log(err);
        });
}

