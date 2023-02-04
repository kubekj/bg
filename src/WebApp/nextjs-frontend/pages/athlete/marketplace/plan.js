import Athlete from "../../../components/layouts/Athlete";
import { getSession } from "next-auth/react";
import fetcher from "../../../lib/rest-api";
import BuyTrainingView from "../../../components/athlete/marketplace/buy-training-view";


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

const AthleteMarketplaceTrainingInfo = ({ jwt, plan }) => {
    return <BuyTrainingView plan={plan}/>
};

export default AthleteMarketplaceTrainingInfo;

AthleteMarketplaceTrainingInfo.layout = Athlete;