import Athlete from "../../../components/layouts/Athlete";
import { getSession } from "next-auth/react";
import fetcher from "../../../lib/rest-api";
import ApplyTrainingView from "../../../components/athlete/training/training-plans/apply-training-view";


export async function getServerSideProps(context) {
    const session = await getSession({ req: context.req });

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

    const id = context.query.id

    const plan = await fetcher(`training-plans/${id}`, options);

    return {
        props: { jwt: session.jwt, plan: plan},
    };
}

const AthleteTrainingInfo = ({ jwt, plan }) => {
    return <ApplyTrainingView plan={plan} jwt={jwt}/>
};

export default AthleteTrainingInfo;

AthleteTrainingInfo.layout = Athlete;