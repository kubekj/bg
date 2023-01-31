import Athlete from "../../../components/layouts/Athlete";
import {getSession} from "next-auth/react";
import fetcher from "../../../lib/rest-api";
import WorkoutsList from "../../../components/athlete-view/athlete-training/workouts/workouts-list";


export async function getServerSideProps(context) {
    const session = await getSession({req: context.req});

    if (!session) {
        return {
            redirect: {
                destination: "/auth/login",
                permanent: false,
            },
        };
    }

    const options = {
        headers: {
            Authorization: `Bearer ${session.jwt}`,
        },
    };

    const response = await fetcher("workouts", options);

    return {
        props: {session: session, jwt: session.jwt, workouts: response},
    }
}

const WorkoutPage = ({workouts, jwt}) => {
    return <WorkoutsList workouts={workouts} jwt={jwt}/>
};

export default WorkoutPage;

WorkoutPage.layout = Athlete;