import PlansList from "../../components/trainer/plans/plans-list";
import Trainer from "../../components/layouts/Trainer";
import {getSession} from "next-auth/react";
import fetcher from "../../lib/rest-api";

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

    const id = context.query.id;

    const plans = await fetcher(`training-plans/created`, options);
    const workouts = await fetcher(`workouts`, options);

    return {
        props: {plans: plans, workouts: workouts},
    };
}

const TrainerDashboard = ({plans, workouts}) => {
    return <PlansList plans={plans} workouts={workouts}/>;
};

export default TrainerDashboard;

TrainerDashboard.layout = Trainer;
