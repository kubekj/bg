import TrainingMain from "../../../components/athlete-view/athlete-training/training-main-view/training-main";
import Athlete from "../../../components/layouts/Athlete";
import {getSession} from "next-auth/react";
import fetcher from "../../../lib/rest-api";


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
    const plans = await fetcher("training-plans", options);

    return {
        props: {session: session, jwt: session.jwt, workouts: workouts, exercises: exercises, plans: plans},
    }
}

const AthleteMainPage = ({workouts, exercises, plans, jwt}) => {
    return <TrainingMain workouts={workouts} exercises={exercises} plans={plans} jwt={jwt}/>
};

export default AthleteMainPage;

AthleteMainPage.layout = Athlete;