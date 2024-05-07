
using System.Data;

public class PatrolState : BaseState
{
    private EnemyFSM enemyFSM;

    public PatrolState(EnemyFSM stateMachine) : base("patrol", stateMachine)
    {
        enemyFSM = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        var patrolAgent = stateMachine.GetComponent<PatrollingAgent>();
        var patrolPoints = stateMachine.GetComponent<PatrolPoints>();
 
        patrolAgent.SetDestination(patrolPoints.GetNext().position);
    }

    public override void Update()
    {
        base.Update();

        var patrolAgent = stateMachine.GetComponent<PatrollingAgent>();
        var patrolPoints = stateMachine.GetComponent<PatrolPoints>();
        
        if (patrolPoints.HasReached(patrolAgent))
            patrolAgent.SetDestination(patrolPoints.GetNext().position);
        
        var sightSensor = stateMachine.GetComponent<EnemySightSensor>();
        if (sightSensor.Ping())
        {
            stateMachine.ChangeState(enemyFSM.chaseState);
        }
    }
}