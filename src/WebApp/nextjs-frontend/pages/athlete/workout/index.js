import Athlete from "../../../components/layouts/Athlete";
import {getSession} from "next-auth/react";
import fetcher from "../../../lib/rest-api";
import WorkoutsList from "../../../components/athlete/training/workouts/workouts-list";

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

    const workouts = await fetcher("workouts", options);
    const exercises = await fetcher("exercises", options);

    return {
        props: {workouts: workouts, exercises: exercises},
    };
}

const WorkoutPage = ({workouts, exercises}) => {
    return <WorkoutsList workouts={workouts} exercises={exercises}/>;
};

export default WorkoutPage;

WorkoutPage.layout = Athlete;
