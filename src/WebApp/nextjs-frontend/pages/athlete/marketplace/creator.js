import Athlete from "../../../components/layouts/Athlete";
import { getSession } from "next-auth/react";
import fetcher from "../../../lib/rest-api";
import CreatorView from "../../../components/athlete/marketplace/creator-view";


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

    const creatorEmail = context.query.creatorEmail;

    const creatorDetails = await fetcher(`users/trainer-details/${creatorEmail}`, options);
    //const recentPlans = await fetcher(`training-plans/most-recent-trainings/${creatorEmail}`, options);

    return {
        props: { jwt: session.jwt, creatorDetails: creatorDetails},
    };
}

const Creator = ({ jwt, creatorDetails, recentPlans }) => {
    return <CreatorView creatorDetails={creatorDetails} />
};

export default Creator;

Creator.layout = Athlete;