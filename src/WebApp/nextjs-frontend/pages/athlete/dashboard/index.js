import DashboardMain from "../../../components/athlete/dashboard/dashboard-main";
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

    //const workouts = await fetcher("workouts", options);
    const current = await fetcher("workouts/current", options);
    const next = await fetcher("workouts/next", options);
    const previous = await fetcher("workouts/previous", options);
    const weightBreakdown = await fetcher("statistics/weight", options);
    const doneTrainings = await fetcher("statistics/trainings", options);

    return {
        props: {
            jwt: session.jwt,
            current: current,
            next: next,
            previous: previous,
            weightBreakdown: weightBreakdown,
            doneTrainings: doneTrainings
        },
    };
}


const AthleteMainPage = ({current, next, previous, weightBreakdown, doneTrainings}) => {
    return <DashboardMain current={current} next={next} previous={previous} weightBreakdown={weightBreakdown}
                          doneTrainings={doneTrainings}/>
};

export default AthleteMainPage;

AthleteMainPage.layout = Athlete;
